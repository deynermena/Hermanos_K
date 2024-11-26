// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Manejar el cambio de tipo de usuario en el modal de login
document.addEventListener('DOMContentLoaded', function() {
    const userTypeButtons = document.querySelectorAll('.login-buttons .btn');
    const userTypeInput = document.getElementById('userType');

    userTypeButtons.forEach(button => {
        button.addEventListener('click', function() {
            // Remover la clase active de todos los botones
            userTypeButtons.forEach(btn => btn.classList.remove('active'));
            
            // Agregar la clase active al botón seleccionado
            this.classList.add('active');
            
            // Actualizar el valor del input hidden
            userTypeInput.value = this.getAttribute('data-type');
        });
    });

    // Manejo del formulario de registro
    document.getElementById('registerForm').addEventListener('submit', function(e) {
        e.preventDefault();
        
        const formData = new FormData(this);
        const errorsDiv = document.getElementById('registerErrors');
        
        fetch('/Account/Register', {
            method: 'POST',
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                window.location.href = data.redirectUrl;
            } else {
                errorsDiv.classList.remove('d-none');
                errorsDiv.innerHTML = data.errors.join('<br>');
            }
        })
        .catch(error => {
            errorsDiv.classList.remove('d-none');
            errorsDiv.textContent = 'Ha ocurrido un error. Por favor, intente nuevamente.';
        });
    });
});
