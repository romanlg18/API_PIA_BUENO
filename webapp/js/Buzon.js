fetch("https://localhost:7246/api/ClienteControlador/ObtenerBuzon").then((data) =>{
    return data.json();
}).then((objectData)=>{
    console.log(objectData[0].idContacto);
    let tableData="";
    objectData.map((values)=>{
        tableData+=`<tr>
        <td>${values.nombre}</td>
        <td>${values.correo}</td>
        <td>${values.asunto}</td>
        <td>${values.mensaje}</td>
            </tr>`
    });
    document.getElementById("table_body").innerHTML=tableData
})
