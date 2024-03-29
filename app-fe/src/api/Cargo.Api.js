import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const CargosApi = axios.create({
  baseURL: `${END_POINT_API}/Cargos`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, filtro) => {
  const res = await CargosApi.get(
    `/Get?pagina=${pagina}&cargoId=${filtro.cargoId}`
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
  const res = await CargosApi.get(`/GetSP`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await CargosApi.post(`/Post`, data)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
