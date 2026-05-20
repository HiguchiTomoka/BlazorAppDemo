/*
ログイン処理
(ブラウザで実行されるため、ブラウザからAPIを呼び出す)
*/
window.login = async (email, password) => {

    const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Email: email,
            Password: password
        })
    });

    return response.ok;
};

/*
ログアウト処理
(ブラウザで実行されるため、ブラウザからAPIを呼び出す)
*/
window.logout = async () => {

    const response = await fetch("/api/auth/logout", {
        method: "POST"
    });

    return response.ok;
};