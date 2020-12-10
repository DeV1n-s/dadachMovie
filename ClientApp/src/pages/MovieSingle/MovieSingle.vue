<template>
  <div>
    <div class="hero mv-single-hero">
      <div class="container">
        <div class="row">
          <div class="col-md-12"></div>
        </div>
      </div>
    </div>
    <div class="container"></div>
    <div class="page-single movie-single movie_single">
      <div class="container">
        <div class="row ipad-width2">
          <div class="col-md-4 col-sm-12 col-xs-12">
            <div class="movie-img sticky-sb">
              <img :src="Movie.picture" alt="" />
              <div class="movie-btn">
                <div class="btn-transform transform-vertical red">
                  <div>
                    <a href="#" class="item item-1 redbtn">
                      <i class="ion-play"></i>مشاهده تریلر</a
                    >
                  </div>
                  <div>
                    <a
                      href="#"
                      class="item item-2 redbtn fancybox-media hvr-grow"
                      ><i class="ion-play"></i
                    ></a>
                  </div>
                </div>
                <div class="btn-transform transform-vertical">
                  <div>
                    <a href="#" class="item item-1 yellowbtn">
                      <i class="ion-card"></i> خرید بلیط</a
                    >
                  </div>
                  <div>
                    <a href="#" class="item item-2 yellowbtn"
                      ><i class="ion-card"></i
                    ></a>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-8 col-sm-12 col-xs-12">
            <div class="movie-single-ct main-content">
              <h1 class="bd-hd">{{ Movie.title }}</h1>
              <div class="social-btn">
                <a href="#" class="parent-btn"
                  ><i class="ion-heart"></i> اضافه کردن به لیست مورد علاقه
                </a>
                <div class="hover-bnt">
                  <a href="#" class="parent-btn"
                    ><i class="ion-android-share-alt"></i>انتشار</a
                  >
                  <div class="hvr-item">
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-facebook"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-twitter"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-googleplus"></i
                    ></a>
                    <a href="#" class="hvr-grow"
                      ><i class="ion-social-youtube"></i
                    ></a>
                  </div>
                </div>
              </div>
              <div class="movie-rate">
                <div class="rate">
                  <i class="ion-android-star"></i>
                  <p><span>8.1</span> /10<br /></p>
                  <div class="rate-star">
                    <p>امتیاز کاربران</p>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star"></i>
                    <i class="ion-ios-star-outline"></i>
                  </div>
                </div>
              </div>
              <div class="movie-tabs">
                <div class="tabs">
                  <div class="tab-content">
                    <div id="overview" class="tab active">
                      <div class="row">
                        <div class="col-md-8 col-sm-12 col-xs-12">
                          <h5>{{ Movie.shortPara }}</h5>
                          <hr />
                          <p>{{ Movie.longPara }}</p>
                          <!-- movie user review -->
                        </div>

                        <div id="reviews">
                          <div class="row">
                            <div class="rv-hd">
                              <div class="div">
                                <h3>Related Movies To</h3>
                                <h2>Skyfall: Quantum of Spectre</h2>
                              </div>
                              <a href="#" class="redbtn">Write Review</a>
                            </div>
                            <div class="topbar-filter">
                              <p>Found <span>56 reviews</span> in total</p>
                              <label>Filter by:</label>
                              <select>
                                <option value="popularity"
                                  >Popularity Descending</option
                                >
                                <option value="popularity"
                                  >Popularity Ascending</option
                                >
                                <option value="rating"
                                  >Rating Descending</option
                                >
                                <option value="rating">Rating Ascending</option>
                                <option value="date"
                                  >Release date Descending</option
                                >
                                <option value="date"
                                  >Release date Ascending</option
                                >
                              </select>
                            </div>
                            <div class="mv-user-review-item">
                              <div class="user-infor">
                                <img src="images/uploads/userava1.jpg" alt="" />
                                <div>
                                  <h3>Best Marvel movie in my opinion</h3>
                                  <div class="no-star">
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star last"></i>
                                  </div>
                                  <p class="time">
                                    17 December 2016 by
                                    <a href="#"> hawaiipierson</a>
                                  </p>
                                </div>
                              </div>
                              <p>
                                This is by far one of my favorite movies from
                                the MCU. The introduction of new Characters both
                                good and bad also makes the movie more exciting.
                                giving the characters more of a back story can
                                also help audiences relate more to different
                                characters better, and it connects a bond
                                between the audience and actors or characters.
                                Having seen the movie three times does not
                                bother me here as it is as thrilling and
                                exciting every time I am watching it. In other
                                words, the movie is by far better than previous
                                movies (and I do love everything Marvel), the
                                plotting is splendid (they really do out do
                                themselves in each film, there are no problems
                                watching it more than once.
                              </p>
                            </div>
                            <div class="mv-user-review-item">
                              <div class="user-infor">
                                <img src="images/uploads/userava2.jpg" alt="" />
                                <div>
                                  <h3>Just about as good as the first one!</h3>
                                  <div class="no-star">
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                  </div>
                                  <p class="time">
                                    17 December 2016 by
                                    <a href="#"> hawaiipierson</a>
                                  </p>
                                </div>
                              </div>
                              <p>
                                Avengers Age of Ultron is an excellent sequel
                                and a worthy MCU title! There are a lot of good
                                and one thing that feels off in my opinion.
                              </p>

                              <p>THE GOOD:</p>

                              <p>
                                First off the action in this movie is amazing,
                                to buildings crumbling, to evil blue eyed robots
                                tearing stuff up, this movie has the action
                                perfectly handled. And with that action comes
                                visuals. The visuals are really good, even
                                though you can see clearly where they are
                                through the movie, but that doesn't detract from
                                the experience. While all the CGI glory is
                                taking place, there are lovable characters that
                                are in the mix. First off the original
                                characters, Iron Man, Captain America, Thor,
                                Hulk, Black Widow, and Hawkeye, are just as
                                brilliant as they are always. And Joss Whedon
                                fixed my main problem in the first Avengers by
                                putting in more Hawkeye and him more fleshed
                                out. Then there is the new Avengers,
                                Quicksilver, Scarletwich, and Vision, they are
                                pretty cool in my opinion. Vision in particular
                                is pretty amazing in all his scenes.
                              </p>

                              <p>THE BAD:</p>

                              <p>
                                The beginning of the film it's fine until
                                towards the second act and there is when it
                                starts to feel a little rushed. Also I do feel
                                like there are scenes missing but there was talk
                                of an extended version on Blu-Ray so that's
                                cool.
                              </p>
                            </div>
                            <div class="mv-user-review-item">
                              <div class="user-infor">
                                <img src="images/uploads/userava3.jpg" alt="" />
                                <div>
                                  <h3>
                                    One of the most boring exepirences from
                                    watching a movie
                                  </h3>
                                  <div class="no-star">
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                  </div>
                                  <p class="time">
                                    26 March 2017 by<a href="#">
                                      christopherfreeman</a
                                    >
                                  </p>
                                </div>
                              </div>
                              <p>
                                I can't right much... it's just so
                                forgettable...Okay, from what I remember, I
                                remember just sitting down on my seat and
                                waiting for the movie to begin. 5 minutes into
                                the movie, boring scene of Tony Stark just
                                talking to his "dead" friends saying it's his
                                fault. 10 minutes in: Boring scene of Ultron and
                                Jarvis having robot space battles(I dunno:/). 15
                                minutes in: I leave the theatre.2nd attempt at
                                watching it: I fall asleep. What woke me up is
                                the next movie on Netflix when the movie was
                                over.
                              </p>

                              <p>Bottemline: It's boring...</p>

                              <p>10/10 because I'm a Marvel Fanboy</p>
                            </div>
                            <div class="mv-user-review-item ">
                              <div class="user-infor">
                                <img src="images/uploads/userava4.jpg" alt="" />
                                <div>
                                  <h3>That spirit of fun</h3>
                                  <div class="no-star">
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                  </div>
                                  <p class="time">
                                    26 March 2017 by <a href="#"> juliawest</a>
                                  </p>
                                </div>
                              </div>
                              <p>
                                If there were not an audience for Marvel comic
                                heroes than clearly these films would not be
                                made, to answer one other reviewer although I
                                sympathize with him somewhat. The world is
                                indeed an infinitely more complex place than the
                                world of Marvel comics with clearly identifiable
                                heroes and villains. But I get the feeling that
                                from Robert Downey, Jr. on down the organizer
                                and prime mover as Iron Man behind the Avengers
                                these players do love doing these roles because
                                it's a lot of fun. If they didn't show that
                                spirit of fun to the audience than these films
                                would never be made.
                              </p>

                              <p>
                                So in that spirit of fun Avengers: Age Of Ultron
                                comes before us and everyone looks like they're
                                having a good time saving the world. A computer
                                program got loose and took form in this
                                dimension named Ultron and James Spader who is
                                completely unrecognizable is running amuck in
                                the earth. No doubt Star Trek fans took notice
                                that this guy's mission is to cleanse the earth
                                much like that old earth probe NOMAD which got
                                its programming mixed up in that classic Star
                                Trek prime story. Wouldst Captain James T. Kirk
                                of the Enterprise had a crew like Downey has at
                                his command.
                              </p>
                              <p>
                                My favorite is always Chris Evans because of the
                                whole cast he best gets into the spirit of being
                                a superhero. Of all of them, he's already played
                                two superheroes, Captain America and Johnny
                                Storm the Human Torch. I'll be before he's done
                                Evans will play a couple of more as long as the
                                money's good and he enjoys it.
                              </p>

                              <p>
                                Pretend you're a kid again and enjoy, don't take
                                it so seriously.
                              </p>
                            </div>
                            <div class="mv-user-review-item last">
                              <div class="user-infor">
                                <img src="images/uploads/userava5.jpg" alt="" />
                                <div>
                                  <h3>Impressive Special Effects and Cast</h3>
                                  <div class="no-star">
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star"></i>
                                    <i class="ion-android-star last"></i>
                                    <i class="ion-android-star last"></i>
                                  </div>
                                  <p class="time">
                                    26 March 2017 by <a href="#"> johnnylee</a>
                                  </p>
                                </div>
                              </div>
                              <p>
                                The Avengers raid a Hydra base in Sokovia
                                commanded by Strucker and they retrieve Loki's
                                scepter. They also discover that Strucker had
                                been conducting experiments with the orphan
                                twins Pietro Maximoff (Aaron Taylor-Johnson),
                                who has super speed, and Wanda Maximoff
                                (Elizabeth Olsen), who can control minds and
                                project energy. Tony Stark (Robert Downey Jr.)
                                discovers an Artificial Intelligence in the
                                scepter and convinces Bruce Banner (Mark
                                Ruffalo) to secretly help him to transfer the
                                A.I. to his Ultron defense system. However, the
                                Ultron understands that is necessary to
                                annihilate mankind to save the planet, attacks
                                the Avengers and flees to Sokovia with the
                                scepter. He builds an armature for
                                self-protection and robots for his army and
                                teams up with the twins. The Avengers go to
                                Clinton Barton's house to recover, but out of
                                the blue, Nick Fury (Samuel L. Jackson) arrives
                                and convinces them to fight against Ultron. Will
                                they succeed?
                              </p>

                              <p>
                                "Avengers: Age of Ultron" is an entertaining
                                adventure with impressive special effects and
                                cast. The storyline might be better, since most
                                of the characters do not show any chemistry.
                                However, it is worthwhile watching this film
                                since the amazing special effects are not
                                possible to be described in words. Why Pietro
                                has to die is also not possible to be explained.
                                My vote is eight.
                              </p>
                            </div>
                            <div class="topbar-filter">
                              <label>Reviews per page:</label>
                              <select>
                                <option value="range">5 Reviews</option>
                                <option value="saab">10 Reviews</option>
                              </select>
                              <div class="pagination2">
                                <span>Page 1 of 6:</span>
                                <a class="active" href="#">1</a>
                                <a href="#">2</a>
                                <a href="#">3</a>
                                <a href="#">4</a>
                                <a href="#">5</a>
                                <a href="#">6</a>
                                <a href="#"
                                  ><i class="ion-arrow-right-b"></i
                                ></a>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="col-md-4 col-xs-12 col-sm-12">
                          <div class="sb-it">
                            <h6>کارگردان</h6>
                            <p>
                              <a href="#">{{ Diractor }}</a>
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>ستاره ها</h6>
                            <p v-for="cast in Cast" :key="cast">
                              {{ cast.personName }}
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>ژانر</h6>
                            <p>
                              {{ Movie.genres[0].name }}
                            </p>
                          </div>
                          <div class="sb-it">
                            <h6>تاریخ انتشار</h6>
                            <p>{{ Movie.releaseDate }}</p>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      Diractor: '',
      Cast: ''
    };
  },
  computed: {
    Movie() {
      return this.$store.getters.Movie(parseInt(this.$route.params.id));
    }
  },
  mounted() {
    this.Diractor = this.Movie.directors[0].personName;
    this.Cast = this.Movie.casters;
  }
};
</script>

<style scoped>
p {
  font-size: 2rem;
}
h5 {
  color: aliceblue;
}
i {
  margin: 5px;
}
h6 {
  margin-top: 0.38rem;
}
</style>
