import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const DireccionApi = axios.create({
  baseURL: `${END_POINT_API}/Direcciones`,
  headers: {
    "Content-Type": "application/json",
    "Authorization": getCookie(),
  },
});

export const get = async () => {
  const res = await DireccionApi.get(`/Get`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
