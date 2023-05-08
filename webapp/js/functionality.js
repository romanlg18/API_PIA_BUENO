window.onload = () => {
  chargeData();
};

const chargeData = () => {
  let info;
  const infoSection = document.getElementById("insurance");

  fetch("https://localhost:7246/api/SeguroControlador/seguros")
    .then((response) => response.json())
    .then((data) => {
      info = data;
      console.log(info);
      info.map(
        (insurance) =>
          (infoSection.innerHTML += `<input type="radio" class="btn-check" name="btnradio" id="${insurance.idSeguros}" value="${insurance.idSeguros}"  checked>
                                        <label class="btn btn-light py-3 " for="${insurance.idSeguros}" ">
                                                ${insurance.seguro}
                                                <p class="insurance-type small text-muted " >${insurance.seguroS_TYPE}</p>
                                        </label>`)
      );
    });
};
