const popup = document.querySelector('.popup');
const closePopup = document.querySelector('#close-popup');
const FormularioAdmin = document.getElementById("form")

const popup2 = document.querySelector('.popup2');
const closePopup2 = document.querySelector('#close-popup2');


FormularioAdmin.addEventListener('submit', function(e) {
  e.preventDefault(); // Evita que el formulario se envíe

    const Nombre = document.getElementById('name').value;
    const Apellido = document.getElementById('apellidos').value;
    const Email = document.getElementById('correo').value;
    const phone = document.getElementById('telefono').value;
    const Fecha = document.getElementById('fecha').value;
    const insurance = document.querySelector('input[name=btnradio]:checked').value;

    var JSONObject ={
    "cL_NOMBRES": Nombre,
    "cL_aPELLIDOS": Apellido,
    "cL_CORREO": Email,
    "cL_NUMERO": phone,
    "idseguros": insurance,
    "fechA_ALTA": Fecha
    }
    console.log(JSONObject);

    if (Nombre && Apellido && Email && phone && Fecha && insurance){
      fetch("https://localhost:7246/api/ClienteControlador/InsertClientes",{
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