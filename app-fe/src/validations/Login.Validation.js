import * as yup from "yup";

export const ValidateUsuario = yup.object().shape({
  nombre_usuario: yup.string().required(),
  password: yup.string().required(),
});
