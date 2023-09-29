import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const PersonaApi = axios.create({
  baseURL: `${END_POINT_API}/Usuario`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, filtros) => {
  const res = await PersonaApi.get(
    `/Get?pagina=${pagina}&usuarioId=${filtros.usuarioId}&rolId=${filtros.rolId}`
  )
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const getSP = async () => {
  const res = await PersonaApi.get(`/GetSP`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await PersonaApi.post(`/Post`, data)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
