```

    Migration Oluşturma (Package Manager Console)
        
        Data Katmanında Migration
            add-migration "app_db1" -Context AppDbContext
            Update-Database -Context AppDbContext 

        WebUI Katmanında Migration
            add-migration "user_db1" -Context UserContext
            Update-Database -Context UserContext 

```
