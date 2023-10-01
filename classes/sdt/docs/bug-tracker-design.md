
# Requirement 1

Given I am in authenticated user
When I POST a valid bug report
Then I recieve the bug report, including a link to the stored report

## REQUEST




### Doing the Postgres Image thing

Connect a shell.

```shell
mkdir /pgdata
cp -r /var/lib/postgresql/data/* /pgdata

```

Exit the shell

Then:
```shell
docker commit dev-environment-db-1
docker images
docker tag ead6ebe65277 jeffrygonzalez/pg-thing:v2
```