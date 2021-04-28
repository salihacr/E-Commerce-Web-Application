```

    Migration Oluşturma (Package Manager Console)
        
        Data Katmanında Migration
            add-migration "migration_ismi" -Context AppDbContext

        WebUI Katmanında Migration
            add-migration "migration_ismi" -Context UserContext

        Update-Database -Context "Context_İsmi"  ile migrationu db ye aktar.

```