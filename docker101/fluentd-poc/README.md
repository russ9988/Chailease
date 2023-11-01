# NLog to Fluentd on Docker POC

此專案為POC展示在本機透過`docker compose`建立Fluentd、elasticsearch、Kibana服務，並透過Demo api專案寫NLog到Fluentd

# 設定步驟

1. 安裝好Docker desktop
2. 到`log/`執行以下語法，建立docker compose服務，建立完成後會有elasticsearch、kibana、fluentd三個服務
    ```
    docker compose build
    docker compose up
    ```
3. 到`api/`執行以下語法，建立Demo API，建立完成後可至`http://localhost:81/swagger/`開啟swagger畫面call api便會寫NLog傳送至fluentd
    ```
    docker compose build
    docker compose up
    ```
    <img src="https://miro.medium.com/v2/resize:fit:1400/format:webp/1*y-9Hilst_6i0kpXrfdjj4g.png"></img>
    
4. 開啟kibana網址(`http://localhost:5601`)，會看到已有資料寫入，須先建立`Index pattern`，建立完成後即可看到NLog已寫入elasticsearch

    <img src="https://miro.medium.com/v2/resize:fit:1100/format:webp/1*AypwYJsOIzk6isfpbZHw6g.png" />
    <img src="https://miro.medium.com/v2/resize:fit:1100/format:webp/1*_BjIR0dhX6mQ8ZJt4rjH3g.png" />

# 參考網站

本專案實作參考文章
[Set up log monitor with authentication for Asp.Net Core 5 Web Api with NLog, Fluentd, Elasticsearch and Kibana](https://zysce.medium.com/set-up-log-monitor-with-authentication-for-asp-net-9de5be63d37)

其他官方文件:

- NLog官方文件 [NLog Targets](https://nlog-project.org/config/?tab=targets)
- 寫入Fluentd的套件 [Github | NLog.Targets.Fluentd](https://github.com/fluent/NLog.Targets.Fluentd)
- 擴充NLog.Targets.Fluentd且支援TLS的套件 [Github | NLog.Fluentd](https://github.com/ALFNeT/NLog.Fluentd)