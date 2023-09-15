import { config } from "dotenv";

config();

const END_POINT_API =
  process.env.END_POINT_API || "http://192.168.1.66:5155/api";
const SECRET_KEY = process.env.SECRET_KEY || "ElGuardaEspaldasDeMessi";
const SECRET_KEY_COOKIE = process.env.SECRET_KEY_COOKIE || "ElGuardaEspaldasDeMessiCookie";

export { END_POINT_API };
export { SECRET_KEY };
export { SECRET_KEY_COOKIE };
