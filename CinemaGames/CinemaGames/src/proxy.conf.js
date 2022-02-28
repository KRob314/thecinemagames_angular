const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7121",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
