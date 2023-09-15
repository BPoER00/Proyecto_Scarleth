import * as yup from "yup";

export const ValidateVacuna = yup.object().shape({
  descripcion: yup.date().required(),
  cantidad: yup.number().required(),
  fecha_vencimiento: yup.number().required(),
  usuario_id: yup.string().required(),
  nombre: yup.number().required(),
  cubre: yup.number().required(),
});
