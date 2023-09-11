
## Postgres with Data Volume

```yaml
services:
  db:
    image: postgres:15.2-bullseye
    environment:
      POSTGRES_PASSWORD: password
    ports:
      - 5432:5432
    volumes:
      - db_data:/var/lib/postgresql/data
volumes:
  db_data:
```


## Postgres with Adminer

```yaml
services:
  db:
    image: postgres:15.2-bullseye
    environment:
      POSTGRES_PASSWORD: password
    ports:
      - 5432:5432
    volumes:
      - db_data:/var/lib/postgresql/data
  adminer:
    image: adminer
    restart: always
    ports:
      - 8080:8080

volumes:
  db_data:
```