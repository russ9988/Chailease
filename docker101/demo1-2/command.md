# 練習建立容器化的資料庫服務

``` powershell
docker run -d --rm --name mssql-container               `
           -p 1433:1433                                 `
           -e "ACCEPT_EULA=Y"                           `
           -e "SA_PASSWORD=1qaz@WSX3edc"                `
           mcr.microsoft.com/mssql/server:2022-latest
```
