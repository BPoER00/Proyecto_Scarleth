import * as yup from "yup";

export const ValidateCargo = yup.object().shape({
  nombre: yup.string().required()
});