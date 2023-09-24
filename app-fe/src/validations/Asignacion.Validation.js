import * as yup from "yup";

export const ValidateAsignacion = yup.object().shape({
  persona_id: yup.number().required("Persona es requerida"),
  numero_colegiado: yup.string().required("Numero de colegiado es requerido"),
  cargo_id: yup.number().required("Cargo es requerido"),
});