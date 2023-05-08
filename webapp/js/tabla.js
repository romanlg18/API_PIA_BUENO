fetch("https://localhost:7246/api/ClienteControlador/ObtenerClientes").then((data) =>{
    return data.json();
}).then((objectData)=>{
    console.log(objectData[0].idCliente);
    let tableData="";
    objectData.map((values)=>{
        tableData+=`<tr>
        <td>${values.idCliente}</td>
        <td>${values.cL_NOMBRES}</td>
        <td>${values.cL_aPELLIDOS}</td>
        <td>${values.cL_CORREO}</td>
        <td>${values.cL_NUMERO}</td>
        <td>${values.seguro}</td>
        <td>${values.estatus}</td>
        <td>${values.fechA_ALTA}</td>
            </tr>`
    });
    document.getElementById("table_body").innerHTML=tableData
})
