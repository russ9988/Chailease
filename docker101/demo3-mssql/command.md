
# MS SQL掛載Bind Mount於本機

輸入以下指令

``` powershell
docker run -d --rm --name mssql-container                                                                           `
           -p 1433:1433                                                                                             `
           -e "ACCEPT_EULA=Y"                                                                                       `
           -e "SA_PASSWORD=1qaz@WSX3edc"                                                                            `
           -v D:\AD\Project\docker101\demo3-mssql\Volume\mssql\data:/var/opt/mssql/data                   `
           -v D:\AD\Project\docker101\demo3-mssql\Volume\mssql\log:/var/opt/mssql/log                 `
           -v D:\AD\Project\docker101\demo3-mssql\Volume\mssql\secrets:/var/opt/mssql/secrets     `
           mcr.microsoft.com/mssql/server:2022-latest
```

- 開啟SSMS，Host輸入「.」或是【<Host IP>, 1433】、帳號sa、密碼，驗證是否可連線上資料庫
- 在資料庫中建立SampleDB資料庫
- 關閉容器，可以在本機路徑看到SampleDB.mdf

# MS SQL掛載Volume於Docker

輸入以下指令

``` powershell
docker run -d --rm --name mssql-container                                                                           `
           -p 1433:1433                                                                                             `
           -e "ACCEPT_EULA=Y"                                                                                       `
           -e "SA_PASSWORD=1qaz@WSX3edc"                                                                            `
           -v MSSQLVolume:/var/opt/mssql/data                   `
           -v MSSQLVolume:/var/opt/mssql/log                 `
           -v MSSQLVolume:/var/opt/mssql/secrets     `
           mcr.microsoft.com/mssql/server:2022-latest
```
