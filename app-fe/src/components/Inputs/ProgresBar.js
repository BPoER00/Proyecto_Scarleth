"use client";
import { css } from "@emotion/react";
import { BeatLoader } from "react-spinners";

function ProgresBar() {
  const override = css`
    display: block;
    margin: 0 auto;
  `;

  return (
    <div className="flex items-center justify-center h-screen" style={{background: "#a7d0ea"}}>
      <BeatLoader color={"#fff"} css={override} size={20} />
    </div>
  );
}

export default ProgresBar;