
# Keycloak

## TODO: Create the Realm Export and Add it Here


```yaml
  keycloak:
      image: quay.io/keycloak/keycloak:22.0.1
      command: ["start-dev", "--import-realm"]
      environment:
        KEYCLOAK_ADMIN: admin
        KEYCLOAK_ADMIN_PASSWORD: TokyoJoe138!
        KC_REALM_NAME: "hypertheory"
      volumes:
        - ./keycloak/realm-export.json:/opt/keycloak/data/import/realm.json:ro
      ports:
        - 8080:8080
```
