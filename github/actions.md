```yaml
name: CI CD Pipeline

on:
  push:
    branches:
      - "**"
    tags:
      - "v*.*.*"


jobs:
  ci:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Unit Test
      run: dotnet test ./BusinessClockApi.UnitTests --no-build --verbosity normal
    - name: Integration Test
      run: dotnet test ./BusinessClockApi.IntegrationTests --no-build --verbosity normal
  
  cd:
    needs: ci
    runs-on: ubuntu-latest

    steps:
    - name: Setup Docker Buildx
      uses: docker/setup-buildx-action@v2
    - name: Docker Login
      uses: docker/login-action@v2.2.0
      with:
        username: ${{secrets.DOCKER_USER}}
        password: ${{secrets.DOCKER_TOKEN}}
    - name: Docker Metadata action
      id: meta
      uses: docker/metadata-action@v4.5.0
      with:
        images: jeffrygonzalez/business-clock-api
        tags: |
            type=ref,event=pr
            type=semver,pattern={{version}}
            type=sha
    - name: Build and Push Docker Images
      uses: docker/build-push-action@v4.1.0
      with:
        file: BusinessClockApi/Dockerfile
        push: true
        tags: ${{steps.meta.outputs.tags }}
        labels: ${{steps.meta.outputs.labels }}
        cache-from: type=gha
        cache-to: type=gha,mode=max
```


This github action `.github\workflows\pipeline.yml` does the following:

## CI Steps
- Checks out the code
- Runs `dotnet restore`
- Runs the Unit Tests
- Runs the Integration Tests

## CD Steps
* Setup Docker Buildx
	* This is needed to use the caching stuff in the Build and Push section
- Logs into your Docker account using secrets:
	- `DOCKER_USER` - Docker Hub user account
	- `DOCKER_TOKEN` - From your Docker Hub account.
- Docker metadata Action
	- This gives us the tags and labels
	- Will use branch name (if new branch), a sha if a commit, or a semver if it is a tag that is pushed.

## Adding Tags to your Repo

```shell

git tag v1.0.7

git push origin --tags

```
