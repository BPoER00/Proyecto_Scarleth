import * as yup from "yup";

export const ValidateUsuario = yup.object().shape({
  persona_id: yup.number().required(),
  nombre_usuario: yup.string().required(),
  correo: yup.string().email().required(),
  password: yup.string().required(),
  password_confirm: yup
    .string()
    .required()
    .oneOf([yup.ref("password"), null], "Las contraseñas deben coincidir"),

  rol_id: yup.number().required(),
});
