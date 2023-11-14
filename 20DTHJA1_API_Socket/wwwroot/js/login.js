function login() {
    // Get values from input fields
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    // Perform authentication (you should handle this securely on the server)
    if (username === "admin" && password === "admin") {
        alert("Login Thành Công");
        // Redirect to the admin dashboard or perform other actions
    } else {
        alert("mật khẩu éo đúng hãy thử lại.");
    }
}
