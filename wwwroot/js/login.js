const apiClient = axios.create({
  baseURL: 'http://localhost:5229',
  headers: {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}` // Token'ı başlık olarak ekleyin
  }
});

apiClient.interceptors.request.use(request => {
  console.log('Starting Request', request);
  return request;
});

apiClient.interceptors.response.use(response => {
  console.log('Response:', response);
  return response;
}, error => {
  console.error('Error:', error);
  return Promise.reject(error);
});
// Request interceptor: Her istekte token'ı ekle
apiClient.interceptors.request.use(config => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, error => {
  return Promise.reject(error);
});

document.getElementById("loginForm").addEventListener("submit", function(event) {
  event.preventDefault();

  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;

console.log(localStorage.getItem('token'))

  // Login isteğini gönder
  apiClient.post('/api/Auth/login', {
    email: email,
    password: password
  })
  .then(response => {
    console.log("API Yanıtı:", response); // Yanıtı konsola yazdır

    // Token'ı localStorage'e kaydet
    localStorage.setItem('token', response.data.token);

    // Giriş sonrası yönlendirme
    window.location.href = '/anasayfa';
  })
  .catch(error => {
    console.error("Giriş hatası:", error);
    if (error.response) {
      console.error("Yanıt verisi:", error.response.data); // Yanıt verisini konsola yazdır
      console.error("Yanıt durumu:", error.response.status); // Yanıt durumunu konsola yazdır
      console.error("Yanıt başlıkları:", error.response.headers); // Yanıt başlıklarını konsola yazdır
    } else if (error.request) {
      console.error("İstek yapıldı ama yanıt alınamadı:", error.request); // İstek verisini konsola yazdır
    } else {
      console.error("Hata mesajı:", error.message); // Hata mesajını konsola yazdır
    }
  });
});
