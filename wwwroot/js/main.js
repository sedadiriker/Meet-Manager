document.addEventListener("DOMContentLoaded", function() {
    const user = JSON.parse(localStorage.getItem('user'));
    console.log(`${user.profilePicture.split('/').pop()}`)

    const username = `${(user.firstName).toLocaleUpperCase('tr-TR')} ${(user.lastName).toLocaleUpperCase('tr-TR')}`
    const profilePictureUrl = `http://localhost:5229/uploads/${user.profilePicture.split('/').pop()}`;

  
    if (user) {
      document.querySelector('.navbar .text-gray-600').textContent = username;
      const imgElement = document.querySelector('.navbar .img-profile');
      imgElement.src = profilePictureUrl
    }
  });