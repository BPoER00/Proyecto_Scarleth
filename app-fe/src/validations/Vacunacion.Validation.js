import * as yup from "yup";

export const ValidateVacuna = yup.object().shape({
  fecha_vacunacion: yup.date().required(),
  dosis: yup.number().required(),
  asignacion_id: yup.number().required(),
  descripcion: yup.string().required(),
  vacuna_id: yup.number().required(),
  persona_id: yup.number().required(),
});
