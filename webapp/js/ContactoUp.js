const popup = document.querySelector('.popup');
const closePopup = document.querySelector('#close-popup');
const Formulario2 = document.getElementById("FormContacto")

const popup2 = document.querySelector('.popup2');
const closePopup2 = document.querySelector('#close-popup2');


Formulario2.addEventListener('submit', function(e) {
  e.preventDefault(); // Evita que el formulario se envíe

    const Nombre = document.getElementById('name').value;
    const Apellido = document.getElementById('email').value;
    const Email = document.getElementById('subject').value;
    const message = document.getElementById('message').value;


    var JSONObject ={
    "nombre": Nombre,
    "correo": Apellido,
    "asunto": Email,
    "mensaje": message
    }
    console.log(JSONObject);

    if (Nombre && Apellido && Email && message){
        fetch("https://localhost:7246/api/ClienteControlador/ContactoInsertar",{
            method: 'POST',
            headers: {
                'accept': 'application/json',
                'Content-type': 'application/json; charset=utf-8'
            },
            body: JSON.stringify(JSONObject)
        })
        .then(respuesta => respuesta.json())


        popup.classList.add('popup-show'); // Muestra la ventana emergente

        closePopup.addEventListener('click', function() {
          popup.classList.remove('popup-show'); // Oculta la ventana emergente
        });
    }
    else
    {
        popup2.classList.add('popup-show2'); // Muestra la ventana emergente

        closePopup2.addEventListener('click', function() {
          popup2.classList.remove('popup-show2'); // Oculta la ventana emergente
        });
    }
});

