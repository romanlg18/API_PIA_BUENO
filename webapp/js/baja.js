const popup = document.querySelector('.popup');
const closePopup = document.querySelector('#close-popup');

const popup2 = document.querySelector('.popup2');
const closePopup2 = document.querySelector('#close-popup2');

const FormBaja = document.getElementById("FormBaja")


FormBaja.addEventListener('submit', evento =>{
    evento.preventDefault()
    const IdCliente = document.getElementById('id').value;
    const Estatus = document.querySelector('input[name=estado]:checked').value;

    var JSONObject ={
    "idCliente": IdCliente,
    "estatusCL": Estatus,
    }
    console.log(JSONObject);


    if (IdCliente && Estatus)
    {
      fetch("https://localhost:7246/api/ClienteControlador/DelUpdateCliente",{
        method: 'PUT',
        headers: {
            'accept': 'application/json',
            'Content-type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(JSONObject) 
      })
      .then(data => console.log(data))
      .catch(err => console.log(err))

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
})


