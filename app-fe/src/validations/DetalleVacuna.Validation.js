import * as yup from "yup";

export const ValidateDetalleVacuna = yup.object().shape({
  descripcion: yup.number().required(),
  cantidad: yup.date().required(),
  fecha_vencimiento: yup.number().required(),
  vacuna_id: yup.number().required(),
  usuario_id: yup.number().required(),
});
