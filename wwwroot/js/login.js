
document.addEventListener("DOMContentLoaded", () => {
  const loginForm = document.getElementById("loginForm");

  document.getElementById("loginForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const URL = "http://localhost:5229/api";

    try {
      const response = await axios.post(`${URL}/auth/login`, {
        email: email,
        password: password,
      });

      if (response.status === 200) {
        alert("Login successful");
        console.log("Token:", response.data.Token);
        window.location.href = "/anasayfa";
      } else {
        throw new Error("Login failed");
      }
    } catch (error) {
      alert("Login failed");
      console.error("Error:", error);
    }
  });
});
