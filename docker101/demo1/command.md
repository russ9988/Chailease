# 練習利將前端站台容器化

1. 將frontend-ui目錄中的Dockerfile，替換為此目錄中的Dcokerfile
2. 輸入以下指令
    - 從demo1切換到該目錄

    ``` powershell
    cd ..\frontend-ui\
    ```

    - 輸入以下指令，建立Image、運行Container

    ``` powershell
    docker build . -t frontend-ui-demo1
    docker run -d --rm -p 4200:4200 --name frontend-ui-demo1-container frontend-ui-demo1
    ```

3. 輸入以下指令，將angular網站跑起來後，可以透過localhost:4200連線上容器中的angular網站。
