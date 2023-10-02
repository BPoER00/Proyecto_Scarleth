import * as yup from "yup";

export const ValidateVacuna = yup.object().shape({
  fecha_vacunacion: yup
    .date()
    .max(new Date(), "La fecha no puede ser mayor que hoy")
    .required("La fecha es requerida"),
  dosis: yup.number().required(),
  asignacion_id: yup.number().required(),
  descripcion: yup.string().required(),
  vacuna_id: yup.number().required(),
  persona_id: yup.number().required(),
});
