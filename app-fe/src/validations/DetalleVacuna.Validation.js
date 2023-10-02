import * as yup from "yup";

export const ValidateDetalleVacuna = yup.object().shape({
  descripcion: yup.string().required(),
  cantidad: yup.number().required(),
  fecha_vencimiento: yup.date().required(),
});
