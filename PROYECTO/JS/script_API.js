function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId());
    console.log('Nombre: ' + profile.getName());
    console.log('Imagen URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());
}
