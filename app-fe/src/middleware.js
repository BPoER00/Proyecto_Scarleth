import { NextResponse } from "next/server";
import { jwtVerify } from "jose";

export async function middleware(request) {
  const jwt = request.cookies.get("ElGuardaEspaldasDeMessiCookie");

  if (!jwt && request.nextUrl.pathname === "/Login")
    return NextResponse.next(new URL("/Login", request.url));

  if (jwt && request.nextUrl.pathname === "/Login")
    return NextResponse.redirect(new URL("/Dashboard", request.url));

  if (jwt && request.nextUrl.pathname === "/Login")
    return NextResponse.redirect(new URL("/Dashboard", request.url));

  try {
    const { payload } = await jwtVerify(
      jwt.value,
      new TextEncoder().encode("ElGuardaEspaldasDeMessi")
    );

    console.log(payload.rol_id);

    const currentTime = Math.floor(Date.now() / 1000);
    if (payload.exp <= currentTime) {
      return NextResponse.redirect(new URL("/Login", request.url));
    }

    const isAdmin = payload.rol_id === "1";


    if (!isAdmin && request.nextUrl.pathname === "/Usuario") {
      return NextResponse.redirect(new URL("/Permisos", request.url));
    }

    return NextResponse.next();
  } catch (error) {
    return NextResponse.redirect(new URL("/Login", request.url));
  }
}

export const config = {
  matcher: [
    "/Login",
    "/Asignacion",
    "/Cargo",
    "/Dashboard",
    "/Persona",
    "/Reportes",
    "/Usuario",
    "/Vacuna",
    "/Vacunacion",
  ],
};
