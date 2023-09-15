import * as yup from "yup";

export const ValidatePersona = yup.object().shape({
  nombre: yup.number().required(),
  cui: yup.number().required(),
  telefono: yup.number().required(),
  fecha_nacimiento: yup.number().required(),
  direccion_id: yup.number().required(),
  genero_id: yup.number().required(),
});
