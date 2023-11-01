# 練習利用Volume將資料保留

1. 將frontend-ui目錄中的Dockerfile，替換為此目錄中的Dcokerfile
2. 輸入以下指令
    - 切換到frontend-ui目錄

    ``` powershell
    cd ..\frontend-ui\
    ```

    - 建立Image、運行Container

    ``` powershell
    docker build . -t frontend-ui-demo2
    docker run -d --rm --name frontend-ui-demo2-container `
                -p 4200:4200                              `
                -v frontend-ui-volume-container:/app/src      `
                frontend-ui-demo2 
    ```

3. 將Angular網站跑起來後，可以透過localhost:4200連線上容器中的Angular網站。
4. 此時於Docker Desktop即可看到已有「frontend-ui-volume-container」Volume建立，
5. 可以透過進入Container後，以vi調整src/app/app.component.html裡面的文字顯示，查看是否有同步變化
    - 透過執行下方指令，進入容器中

    ``` bash
    docker exec -it frontend-ui-demo2-container sh
    ```
