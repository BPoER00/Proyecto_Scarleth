function formatearFecha(fechaISO) {
  const fecha = new Date(fechaISO);
  const dia = fecha.getDate().toString().padStart(2, "0");
  const mes = (fecha.getMonth() + 1).toString().padStart(2, "0");
  const año = fecha.getFullYear();
  return `${dia}/${mes}/${año}`;
}

export default formatearFecha;
