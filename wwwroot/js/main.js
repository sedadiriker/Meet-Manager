document.addEventListener("DOMContentLoaded", function() {
    const user = JSON.parse(localStorage.getItem('user'));
    const username = `${(user.firstName).toLocaleUpperCase('tr-TR')} ${(user.lastName).toLocaleUpperCase('tr-TR')}`
    console.log(user)
  
    if (user) {
      document.querySelector('.navbar .text-gray-600').textContent = username;
    }
  });