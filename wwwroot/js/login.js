document.addEventListener("DOMContentLoaded", () => {
  const loginForm = document.getElementById("loginForm");

  loginForm.addEventListener("submit", async (e) => {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const URL = "http://localhost:5229/api";

    try {
      const response = await axios.post(`${URL}/auth/login`, {
        email: email,
        password: password,
      });

      console.log("API Yanıtı:", response.data);

      if (response.status === 200) {
        const token = response.data.token; // Token'ı küçük harfle alın
        console.log("Alınan Token:", token); // Token'ı kontrol edin

        if (token) {
          localStorage.setItem("token", token); // Token'ı localStorage'a yazın
          alert("Giriş başarılı");
          window.location.href = "/anasayfa"; // Yönlendirme
        } else {
          throw new Error("Token alınamadı");
        }
      } else {
        throw new Error("Giriş başarısız");
      }
    } catch (error) {
      console.error("Hata:", error.message);
      alert("Giriş başarısız");
    }
  });
});
