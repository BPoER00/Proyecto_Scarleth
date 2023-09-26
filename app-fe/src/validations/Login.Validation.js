import * as yup from "yup";

export const ValidateUsuario = yup.object().shape({
  nombre_usuario: yup.string().required("Nombre de usuario es requerido"),
  password: yup.string().required("Password de usuario es requerido"),
});
