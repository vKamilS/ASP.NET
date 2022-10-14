Vue.component('k-navbar', {
    template:
    `
        <v-app-bar app color="indigo accent-3 pa-0" height=75px>
                
                    <v-app-bar-nav-icon class="white--text" @@click="drawler = !drawler" ></v-app-bar-nav-icon>
                    <v-toolbar-title>
                        <h3 class="font-weight-bold mt-3 pt-2 white--text">BlogPost App</h3>
                        <p class="white--text">Actual site</p>
                    </v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-btn class="indigo darken-3">
                        <span class="white--text">Sign In</span>
                        <v-icon right class="white--text">mdi-login</v-icon>
                    </v-btn>
            </v-app-bar>

            <v-navigation-drawer v-model="drawler" app class="indigo accent-3">
                <v-container >
                    <v-row justify="end">
                        <v-btn fab small @@click="drawler = !drawler" class="indigo darken-3 white--text">
                            <v-icon>mdi-close</v-icon>
                        </v-btn>
                    </v-row>
                    <v-row>
                        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">
                            <v-btn>
                                Home page
                            </v-btn>
                        </a>
                    </v-row>
                    <v-row>
                        <a class="nav-link text-dark" asp-area="" asp-controller="BlogPosts" asp-action="Index">
                            <v-btn>
                                BlogPosts page
                            </v-btn>
                        </a>
                    </v-row>
                    <v-row>
                        <a class="nav-link text-dark" asp-area="" asp-controller="Users" asp-action="Index">
                            <v-btn>
                                Users page
                            </v-btn>
                        </a>
                    </v-row>
                    <v-row>
                        <a class="nav-link text-dark" asp-area="" asp-controller="Contact" asp-action="Index">
                            <v-btn>
                                Contact pege
                            </v-btn>
                        </a>
                    </v-row>
                </v-container>
            </v-navigation-drawer>
    `
})

      