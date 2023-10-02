import * as yup from "yup";

export const ValidateVacuna = yup.object().shape({
  descripcion: yup.string().required(),
  cantidad: yup.number().required(),
  fecha_vencimiento: yup.date().required(),
  nombre: yup.string().required(),
  cubre: yup.string().required(),
  dosis: yup.number().required(),
});
