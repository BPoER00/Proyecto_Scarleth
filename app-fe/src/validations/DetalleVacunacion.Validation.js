import * as yup from "yup";

export const ValidateDetalleVacunacion = yup.object().shape({
  vacunacion_id: yup.number().required(),
  fecha_vacunacion: yup.date().required(),
  dosis: yup.number().required(),
  asignacion_id: yup.number().required(),
});
