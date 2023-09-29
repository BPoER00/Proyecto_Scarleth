import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const AsignacionApi = axios.create({
  baseURL: `${END_POINT_API}/Asignacion`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, filtros) => {
  const res = await AsignacionApi.get(
    `/Get?pagina=${pagina}&personaId=${filtros.personaId}&cargoId=${filtros.cargoId}`
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
  const res = await AsignacionApi.get(`/GetSP`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await AsignacionApi.post(`/Post`, data)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
