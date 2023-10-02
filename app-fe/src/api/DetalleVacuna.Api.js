import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const DetalleVacunaApi = axios.create({
  baseURL: `${END_POINT_API}/DetalleVacunas`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, idVacuna) => {
  const res = await DetalleVacunaApi.get(
    `/Get?pagina=${pagina}&idVacuna=${idVacuna}`
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
  const res = await DetalleVacunaApi.post(`/Post`, data)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
