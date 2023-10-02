import * as yup from "yup";

export const ValidateAsignacion = yup.object().shape({
  persona_id: yup.number().required("Persona es requerida"),
  numero_colegiado: yup.string(),
  cargo_id: yup.number().required("Cargo es requerido"),
});