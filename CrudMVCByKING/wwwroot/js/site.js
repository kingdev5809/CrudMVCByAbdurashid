// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const toggleButton = document.querySelector('#sidebar_button');
const toggleButtonProfile = document.querySelector('#user-menu-button');

toggleButton.addEventListener('click', function () {
    const sidebar = document.querySelector('#default-sidebar');
    sidebar.classList.toggle('active');
    console.log('Hello Func')
});

toggleButtonProfile.addEventListener('click', function () {
    const sidebar = document.querySelector('#user-dropdown');
    sidebar.classList.toggle('active');
    console.log('Hello Func')
});


