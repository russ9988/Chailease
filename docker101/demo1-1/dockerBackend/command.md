# 練習建立容器化的後端程式

依照以下指令執行

- 切換至demo1-1 Dockerfile目錄
    `cd <folderPath>`
- 執行以下指令
  - 建立Image、運行Contaier

    ```bash
    docker build . -t dockerbackend-demo1-1-iamge
    docker run -d --rm -p 5208:5208 --name dockerbackend-demo1-1-container dockerbackend-demo1-1-iamge
    ```
  - 網頁URL輸入此串 [網址](http://localhost:5208/WeatherForecast/) ，確認有取得天氣資訊，即完成透過Host存取容器中的API。
