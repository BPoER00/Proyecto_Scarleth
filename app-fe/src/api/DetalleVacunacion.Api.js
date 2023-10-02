import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const DetalleVacunacionApi = axios.create({
  baseURL: `${END_POINT_API}/DetalleVacunacion`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, personaId) => {
  const res = await DetalleVacunacionApi.get(
    `/Get?pagina=${pagina}&idPersona=${personaId}`
  )
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await DetalleVacunacionApi.post(`/Post`, data)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
