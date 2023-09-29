const FormatearFecha = (fecha) => {
  if (fecha != undefined) {
    const partes = fecha.split("-");
    if (partes.length === 3) {
      return `${partes[1]}-${partes[2]}-${partes[0]}`;
    }
  }
  return "";
};

export default FormatearFecha;
