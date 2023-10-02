import * as yup from "yup";

export const ValidateDetalleVacunacion = yup.object().shape({
  fecha_vacunacion: yup.date().required(),
  dosis: yup.number().required(),
  asignacion_id: yup.number().required(),
});
