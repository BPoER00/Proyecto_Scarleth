import * as yup from "yup";

export const ValidateAsignacion = yup.object().shape({
  persona_id: yup.number().required(),
  numero_colegiado: yup.string().required(),
  cargo_id: yup.number().required(),
});